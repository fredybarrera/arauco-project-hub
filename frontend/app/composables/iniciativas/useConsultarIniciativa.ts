import {
  AutenticacionRequeridaError,
  consultarIniciativa,
  IniciativaNoEncontradaError,
  type IniciativaConsultada
} from '../../api/iniciativas/consultarIniciativa'
import { useAutenticacionIniciativas } from './useAutenticacionIniciativas'

type EstadoConsulta =
  | 'inicial'
  | 'cargando'
  | 'encontrada'
  | 'noEncontrada'
  | 'autenticacionRequerida'
  | 'falloTecnico'

export function useConsultarIniciativa() {
  const estado = ref<EstadoConsulta>('inicial')
  const iniciativa = shallowRef<IniciativaConsultada>()
  const { obtenerAccessToken } = useAutenticacionIniciativas()

  async function ejecutar(iniciativaId: string) {
    estado.value = 'cargando'
    iniciativa.value = undefined

    try {
      const accessToken = await obtenerAccessToken()
      iniciativa.value = await consultarIniciativa(iniciativaId, accessToken)
      estado.value = 'encontrada'
    } catch (error) {
      if (error instanceof IniciativaNoEncontradaError) {
        estado.value = 'noEncontrada'
        return
      }

      if (error instanceof AutenticacionRequeridaError) {
        estado.value = 'autenticacionRequerida'
        return
      }

      estado.value = 'falloTecnico'
    }
  }

  return {
    estado: readonly(estado),
    iniciativa: readonly(iniciativa),
    ejecutar
  }
}
