export interface IniciativaConsultada {
  iniciativaId: string
  negocio: {
    negocioId: string
    nombre: string
  }
  nombre: string
  estadoIniciativa: string
}

export class IniciativaNoEncontradaError extends Error {}

export class AutenticacionRequeridaError extends Error {}

export class RespuestaInvalidaError extends Error {}

type SolicitudHttp = (
  input: RequestInfo | URL,
  init?: RequestInit
) => Promise<Response>

export async function consultarIniciativa(
  iniciativaId: string,
  accessToken: string,
  solicitud: SolicitudHttp = fetch
): Promise<IniciativaConsultada> {
  const respuesta = await solicitud(`/api/iniciativas/${iniciativaId}`, {
    headers: {
      Authorization: `Bearer ${accessToken}`
    },
    signal: AbortSignal.timeout(15_000)
  })

  if (respuesta.status === 401) {
    throw new AutenticacionRequeridaError()
  }

  if (respuesta.status === 404) {
    throw new IniciativaNoEncontradaError()
  }

  if (!respuesta.ok) {
    throw new Error('No fue posible consultar la Iniciativa.')
  }

  const contenido: unknown = await respuesta.json()

  if (!esIniciativaConsultada(contenido)) {
    throw new RespuestaInvalidaError()
  }

  return contenido
}

function esIniciativaConsultada(
  contenido: unknown
): contenido is IniciativaConsultada {
  if (!contenido || typeof contenido !== 'object') {
    return false
  }

  const iniciativa = contenido as Record<string, unknown>
  const negocio = iniciativa.negocio

  return (
    typeof iniciativa.iniciativaId === 'string' &&
    typeof iniciativa.nombre === 'string' &&
    typeof iniciativa.estadoIniciativa === 'string' &&
    !!negocio &&
    typeof negocio === 'object' &&
    typeof (negocio as Record<string, unknown>).negocioId === 'string' &&
    typeof (negocio as Record<string, unknown>).nombre === 'string'
  )
}
