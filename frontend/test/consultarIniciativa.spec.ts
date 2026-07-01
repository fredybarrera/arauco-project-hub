import { describe, expect, it, vi } from 'vitest'
import {
  consultarIniciativa,
  IniciativaNoEncontradaError,
  RespuestaInvalidaError
} from '../app/api/iniciativas/consultarIniciativa'

describe('consultar Iniciativa', () => {
  it('interpreta el contrato aprobado', async () => {
    const solicitud = vi.fn().mockResolvedValue(
      Response.json({
        iniciativaId: 'iniciativa-1',
        negocio: {
          negocioId: 'negocio-1',
          nombre: 'Celulosa'
        },
        nombre: 'Optimización Operacional',
        estadoIniciativa: 'Idea'
      })
    )

    const resultado = await consultarIniciativa(
      'iniciativa-1',
      'access-token-prueba',
      solicitud
    )

    expect(resultado.nombre).toBe('Optimización Operacional')
    expect(solicitud).toHaveBeenCalledWith(
      '/api/iniciativas/iniciativa-1',
      expect.objectContaining({
        headers: {
          Authorization: 'Bearer access-token-prueba'
        }
      })
    )
  })

  it('distingue una Iniciativa no encontrada', async () => {
    const solicitud = vi.fn().mockResolvedValue(
      new Response(null, { status: 404 })
    )

    await expect(
      consultarIniciativa('iniciativa-1', 'token', solicitud)
    ).rejects.toBeInstanceOf(IniciativaNoEncontradaError)
  })

  it('rechaza una respuesta que no cumple el contrato', async () => {
    const solicitud = vi.fn().mockResolvedValue(
      Response.json({ iniciativaId: 'iniciativa-1' })
    )

    await expect(
      consultarIniciativa('iniciativa-1', 'token', solicitud)
    ).rejects.toBeInstanceOf(RespuestaInvalidaError)
  })
})
