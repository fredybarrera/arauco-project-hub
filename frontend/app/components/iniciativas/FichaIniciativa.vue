<script setup lang="ts">
import type { IniciativaConsultada } from '../../api/iniciativas/consultarIniciativa'

defineProps<{
  iniciativa: IniciativaConsultada
}>()
</script>

<template>
  <article class="ficha">
    <div class="riel" aria-hidden="true"></div>

    <header class="encabezado">
      <p class="contexto">Iniciativa</p>
      <h1>{{ iniciativa.nombre }}</h1>
    </header>

    <dl class="datos">
      <div>
        <dt>Negocio</dt>
        <dd>{{ iniciativa.negocio.nombre }}</dd>
      </div>
      <div>
        <dt>Estado de Iniciativa</dt>
        <dd class="estado">
          <span aria-hidden="true"></span>
          {{ iniciativa.estadoIniciativa }}
        </dd>
      </div>
    </dl>
  </article>
</template>

<style scoped>
.ficha {
  position: relative;
  display: grid;
  grid-template-columns: 0.55rem minmax(0, 1fr);
  gap: clamp(1.5rem, 4vw, 3.5rem);
  width: min(100%, 66rem);
  overflow: hidden;
  background: #fff;
  border: 1px solid #dce5e0;
  box-shadow: 0 1.5rem 4rem rgb(18 56 45 / 8%);
}

.riel {
  grid-row: 1 / 3;
  background: linear-gradient(#12382d 0 58%, #2f6e58 58% 82%, #c9962e 82%);
}

.encabezado {
  padding: clamp(2rem, 6vw, 5rem) clamp(2rem, 6vw, 5rem) 2rem 0;
}

.contexto,
dt {
  margin: 0;
  color: #2f6e58;
  font-size: 0.72rem;
  font-weight: 760;
  letter-spacing: 0.14em;
  text-transform: uppercase;
}

h1 {
  max-width: 15ch;
  margin: 0.7rem 0 0;
  color: #12382d;
  font-size: clamp(2.4rem, 7vw, 5.3rem);
  font-weight: 650;
  letter-spacing: -0.055em;
  line-height: 0.98;
  overflow-wrap: anywhere;
}

.datos {
  display: grid;
  grid-template-columns: repeat(2, minmax(0, 1fr));
  margin: 0;
  border-top: 1px solid #e7efeb;
}

.datos > div {
  padding: 1.7rem clamp(1.5rem, 4vw, 3rem) 2rem 0;
}

.datos > div + div {
  padding-left: clamp(1.5rem, 4vw, 3rem);
  border-left: 1px solid #e7efeb;
}

dd {
  margin: 0.55rem 0 0;
  color: #17221e;
  font-size: 1.15rem;
  font-weight: 620;
}

.estado {
  display: flex;
  align-items: center;
  gap: 0.65rem;
}

.estado span {
  width: 0.7rem;
  height: 0.7rem;
  background: #c9962e;
  border: 2px solid #f4e3b9;
  border-radius: 50%;
  box-shadow: 0 0 0 2px #c9962e;
}

@media (max-width: 600px) {
  .datos {
    grid-template-columns: 1fr;
  }

  .datos > div + div {
    padding-left: 0;
    border-top: 1px solid #e7efeb;
    border-left: 0;
  }
}
</style>
