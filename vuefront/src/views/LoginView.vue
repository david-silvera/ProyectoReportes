<template>
    <div class="login-container">
      <h2 class="login-title">Iniciar Sesión</h2>
      <form @submit.prevent="login">
        <label for="username">Usuario</label>
        <input type="text" v-model="username" id="username" placeholder="Tu nombre de usuario" required />
  
        <label for="password">Contraseña</label>
        <input type="password" v-model="password" id="password" placeholder="Tu contraseña" required />
  
        <button type="submit" class="login-btn">Ingresar</button>
      </form>
      <div class="register-link">
        ¿No tienes cuenta?
        <a href="#">Regístrate aquí</a>
      </div>
    </div>
  </template>
  
  <script>
export default {
  name: 'LoginView',
  data() {
    return {
      username: '',
      password: '',
      usuarios: [ 
        {
          id: 1,
          nombre: 'Frank',
          apellido: 'Maldonado',
          username: 'frank',
          contraseña: '1234'
        },
        {
          id: 2,
          nombre: 'Steven',
          apellido: 'Barrios',
          username: 'steven',
          contraseña: '12345'
        }
      ]
    };
  },
  methods: {
    login(event) {
      event.preventDefault(); 
      const user = this.usuarios.find(
        u => u.username === this.username && u.contraseña === this.password
      );

      if (user) {
        alert(`Bienvenido, ${user.nombre} ${user.apellido}`);
        this.$router.push({ 
        name: 'vistaprincipal', 
        query: {
            nombre: user.nombre,
            apellido: user.apellido,
            idusuario: user.id
            }
      });
      }else {
        this.error = 'Usuario o contraseña incorrectos';
      }
    }
  }
};
</script>

  
  <style scoped>
  
  body {
    background-color: #F9FAFB;
  }
  
  .login-container {
    background-color: #ffffff;
    padding: 2rem;
    border-radius: 1rem;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
    width: 100%;
    max-width: 400px;
    margin: 5rem auto;
  }
  
  .login-title {
    text-align: center;
    color:#1F2937;
    font-size: 1.8rem;
    margin-bottom: 1.5rem;
  }
  
  label {
    display: block;
    color: #1F2937;
    margin-bottom: 0.5rem;
    font-weight: bold;
  }
  
  input[type="text"],
  input[type="password"] {
    width: 100%;
    padding: 0.75rem;
    margin-bottom: 1rem;
    border: 1px solid #ccc;
    border-radius: 0.5rem;
    font-size: 1rem;
  }
  
  .login-btn {
    background-color: #ffffff;
    color:#1F2937;
    border: none;
    padding: 0.75rem;
    width: 100%;
    font-size: 1rem;
    border-radius: 0.5rem;
    cursor: pointer;
    transition: background-color 0.3s ease;
  }
  
  .login-btn:hover {
    background-color: #ea580c;
  }
  
  .register-link {
    text-align: center;
    margin-top: 1rem;
    font-size: 0.9rem;
  }
  
  .register-link a {
    color:#1F2937;
    text-decoration: none;
  }
  
  .register-link a:hover {
    text-decoration: underline;
  }
  </style>
  