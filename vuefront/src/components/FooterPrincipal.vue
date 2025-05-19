<template>
    <footer class="footer">
      <p>&copy; 2025 Mi Sitio de Noticias. Todos los derechos reservados.</p>
      <div class="enlaces">
        <a href="#">Aviso legal</a>
        <a href="#">Política de privacidad</a>
        <a href="#">Contacto</a>
      </div>
    </footer>
  </template>
  
  <script>
  export default {
    name: 'FooterPrincipal'
  };
  </script>
  
  <style scoped>
  .footer {
    background-color: #2c3e50;
    color: #ecf0f1;
    text-align: center;
    padding: 20px;
    margin-top: 40px;
    font-size: 14px;
  }
  
  .enlaces {
    margin-top: 10px;
    display: flex;
    justify-content: center;
    gap: 20px;
    flex-wrap: wrap;
  }
  
  .enlaces a {
    color: #ecf0f1;
    text-decoration: none;
    transition: color 0.2s ease;
  }
  
  .enlaces a:hover {
    color: #3498db;
  }
  </style>
  