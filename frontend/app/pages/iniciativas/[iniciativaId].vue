<script setup lang="ts">
import FichaIniciativa from '../../components/iniciativas/FichaIniciativa.vue'
import { useAutenticacionIniciativas } from '../../composables/iniciativas/useAutenticacionIniciativas'
import { useConsultarIniciativa } from '../../composables/iniciativas/useConsultarIniciativa'

const route = useRoute()
const { estado, iniciativa, ejecutar } = useConsultarIniciativa()
const { cerrarAutenticacion } = useAutenticacionIniciativas()

onMounted(() => {
  void ejecutar(String(route.params.iniciativaId))
})
</script>

<template>
  <main class="pagina">
    <nav aria-label="Contexto">
      <NuxtLink to="/">Arauco Project Hub</NuxtLink>
      <span aria-hidden="true">/</span>
      <span>Iniciativa</span>
    </nav>

    <section v-if="estado === 'cargando' || estado === 'inicial'" class="mensaje" aria-live="polite">
      <p class="etiqueta">Consultando</p>
      <h1>Recuperando la Iniciativa…</h1>
    </section>

    <section v-else-if="estado === 'encontrada' && iniciativa" class="resultado">
      <FichaIniciativa :iniciativa="iniciativa" />
      <button class="cerrar" type="button" @click="cerrarAutenticacion">
        Cerrar autenticación
      </button>
    </section>

    <section v-else-if="estado === 'noEncontrada'" class="mensaje" role="status">
      <p class="etiqueta">Sin resultado</p>
      <h1>No fue posible encontrar la Iniciativa.</h1>
      <p>Verifique el vínculo de acceso o consulte con la persona responsable.</p>
    </section>

    <section v-else-if="estado === 'autenticacionRequerida'" class="mensaje" role="alert">
      <p class="etiqueta">Autenticación requerida</p>
      <h1>Su contexto de autenticación ya no es válido.</h1>
      <button type="button" @click="ejecutar(String(route.params.iniciativaId))">
        Iniciar nuevamente
      </button>
    </section>

    <section v-else class="mensaje" role="alert">
      <p class="etiqueta">Consulta interrumpida</p>
      <h1>No fue posible consultar la Iniciativa.</h1>
      <button type="button" @click="ejecutar(String(route.params.iniciativaId))">
        Reintentar
      </button>
    </section>
  </main>
</template>

<style scoped>
.pagina {
  min-height: 100vh;
  padding: clamp(1.25rem, 4vw, 3rem) clamp(1.25rem, 7vw, 7rem)
    clamp(3rem, 8vw, 7rem);
  background:
    radial-gradient(circle at 88% 12%, rgb(47 110 88 / 9%), transparent 26rem),
    #f7f9f7;
}

nav {
  display: flex;
  gap: 0.7rem;
  margin-bottom: clamp(3rem, 9vh, 7rem);
  color: #65736d;
  font-size: 0.8rem;
  font-weight: 650;
}

nav a {
  color: #2f6e58;
  text-decoration-thickness: 1px;
  text-underline-offset: 0.25rem;
}

.mensaje {
  max-width: 52rem;
  padding-left: clamp(1.5rem, 4vw, 3rem);
  border-left: 0.55rem solid #12382d;
}

.etiqueta {
  margin: 0 0 0.8rem;
  color: #2f6e58;
  font-size: 0.72rem;
  font-weight: 760;
  letter-spacing: 0.14em;
  text-transform: uppercase;
}

.mensaje h1 {
  margin: 0;
  color: #12382d;
  font-size: clamp(2rem, 6vw, 4.5rem);
  letter-spacing: -0.05em;
  line-height: 1;
}

.mensaje p:not(.etiqueta) {
  max-width: 38rem;
  color: #53615b;
  line-height: 1.65;
}

button {
  margin-top: 1.25rem;
  padding: 0.8rem 1.1rem;
  color: #fff;
  background: #12382d;
  border: 0;
  cursor: pointer;
  font-weight: 700;
}

button:hover {
  background: #2f6e58;
}

.resultado {
  width: min(100%, 66rem);
}

.cerrar {
  margin-top: 1.2rem;
  color: #2f6e58;
  background: transparent;
  border: 1px solid #b9cbc2;
}

.cerrar:hover {
  color: #fff;
}

@media (prefers-reduced-motion: no-preference) {
  .ficha,
  .mensaje {
    animation: entrada 380ms ease-out both;
  }

  @keyframes entrada {
    from {
      opacity: 0;
      transform: translateY(0.8rem);
    }
  }
}
</style>
