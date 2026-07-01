<template>
  <main class="inicio">
    <p class="producto">Arauco Project Hub</p>
    <h1>El contexto de cada Iniciativa, en un solo lugar.</h1>
    <p class="descripcion">
      Abra una Iniciativa desde su vínculo de acceso para consultar el Negocio
      y su estado vigente.
    </p>
  </main>
</template>

<style scoped>
.inicio {
  display: grid;
  align-content: center;
  min-height: 100vh;
  padding: clamp(2rem, 8vw, 8rem);
  background:
    linear-gradient(90deg, #12382d 0 0.6rem, transparent 0.6rem),
    #f7f9f7;
}

.producto {
  margin: 0 0 1.5rem;
  color: #2f6e58;
  font-size: 0.78rem;
  font-weight: 750;
  letter-spacing: 0.14em;
  text-transform: uppercase;
}

h1 {
  max-width: 16ch;
  margin: 0;
  color: #12382d;
  font-size: clamp(2.5rem, 7vw, 5.8rem);
  font-weight: 650;
  letter-spacing: -0.055em;
  line-height: 0.98;
}

.descripcion {
  max-width: 38rem;
  margin: 2rem 0 0;
  color: #53615b;
  font-size: clamp(1rem, 2vw, 1.2rem);
  line-height: 1.65;
}
</style>
