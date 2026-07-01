import {
  BrowserCacheLocation,
  InteractionRequiredAuthError,
  PublicClientApplication,
  type Configuration
} from '@azure/msal-browser'

let clientePromise: Promise<PublicClientApplication> | undefined

export function useAutenticacionIniciativas() {
  const configuracion = useRuntimeConfig()

  async function obtenerAccessToken(): Promise<string> {
    const cliente = await obtenerCliente()
    const retorno = await cliente.handleRedirectPromise()
    const cuenta = retorno?.account ?? cliente.getAllAccounts()[0]

    if (!cuenta) {
      await cliente.loginRedirect({
        scopes: [configuracion.public.entraApiScope]
      })
      throw new Error('Autenticación redirigida.')
    }

    try {
      const resultado = await cliente.acquireTokenSilent({
        account: cuenta,
        scopes: [configuracion.public.entraApiScope]
      })
      return resultado.accessToken
    } catch (error) {
      if (error instanceof InteractionRequiredAuthError) {
        await cliente.acquireTokenRedirect({
          account: cuenta,
          scopes: [configuracion.public.entraApiScope]
        })
      }

      throw error
    }
  }

  async function cerrarAutenticacion(): Promise<void> {
    const cliente = await obtenerCliente()
    const cuenta = cliente.getAllAccounts()[0]

    await cliente.logoutRedirect({
      account: cuenta,
      postLogoutRedirectUri: window.location.origin
    })
  }

  async function obtenerCliente(): Promise<PublicClientApplication> {
    if (!clientePromise) {
      validarConfiguracion()

      const msalConfiguracion: Configuration = {
        auth: {
          clientId: configuracion.public.entraClientId,
          authority:
            `https://login.microsoftonline.com/` +
            configuracion.public.entraTenantId,
          redirectUri: window.location.origin
        },
        cache: {
          cacheLocation: BrowserCacheLocation.MemoryStorage
        }
      }

      clientePromise = (async () => {
        const cliente = new PublicClientApplication(msalConfiguracion)
        await cliente.initialize()
        return cliente
      })()
    }

    return await clientePromise
  }

  function validarConfiguracion() {
    if (
      !configuracion.public.entraClientId ||
      !configuracion.public.entraTenantId ||
      !configuracion.public.entraApiScope
    ) {
      throw new Error(
        'La autenticación de Microsoft Entra ID no está configurada.'
      )
    }
  }

  return { obtenerAccessToken, cerrarAutenticacion }
}
