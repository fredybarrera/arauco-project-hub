export default defineNuxtConfig({
  compatibilityDate: '2026-07-01',
  devtools: { enabled: false },
  ssr: false,
  runtimeConfig: {
    public: {
      entraClientId: '',
      entraTenantId: '',
      entraApiScope: ''
    }
  },
  vite: {
    optimizeDeps: {
      include: ['@azure/msal-browser']
    }
  },
  typescript: {
    typeCheck: true
  }
})
