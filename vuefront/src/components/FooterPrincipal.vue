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
  * {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
  .footer {
  background-color: #263238;
  color: white;
  text-align: center;
  padding: 20px;
  font-size: 14px;
  margin-top: auto;
}

.footer a {
  color: #90caf9;
  margin: 0 10px;
  text-decoration: none;
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
  