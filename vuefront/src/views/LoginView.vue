<template>
  <video class="banner" autoplay loop muted playsinline>
        <source src="../assets/213102_tiny.mp4" type="video/mp4">
    </video>
    <div class="login-container">
      <h2 class="login-title">Iniciar Sesión</h2>
       <div v-if="mensaje" :class="['mensaje', tipoMensaje]">
      {{ mensaje }}
      </div>
      <form @submit.prevent="login">
        <label for="username">Usuario</label>
        <input type="text" v-model="username" id="username" placeholder="Tu nombre de usuario" required />
  
        <label for="password">Contraseña</label>
        <input type="password" v-model="password" id="password" placeholder="Tu contraseña" required />
  
        <button type="submit" class="login-btn">Ingresar</button>
      </form>
     <div class="register-link">
      ¿No tienes cuenta?
      <a @click.prevent="$router.push({ name: 'registroview' })" href="#">Regístrate aquí</a>
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
      usuarios:[],
       mensaje: "",
      tipoMensaje: "", 
    };
  },
  methods: {
    getAllUsuarios: async function(){
      let url="http://localhost:5272/api/Usuario";
      let vue = this;
      await this.axios
      .get(url)
      .then(function (response){
        vue.usuarios = response.data;
        console.log(vue.usuarios);
        this.usuarios = response.data;
      })
      .catch(function(error){
        console.log(error)
      })
      .finally(function(){});
    },
    
    login(event) {
      event.preventDefault(); 
      const user = this.usuarios.find(
        u => u.username === this.username && u.contraseña === this.password
      );

      if (user) {
        this.mensaje = `Bienvenido, ${user.nombre} ${user.apellido}`;
        this.tipoMensaje = "success";
        setTimeout(() => {
          this.$router.push({
            name: "vistaprincipal",
            query: {
              nombre: user.nombre,
              apellido: user.apellido,
              idusuario: user.id,
            },
          });
        }, 1500); 
      } else {
        this.mensaje = "Usuario o contraseña incorrectos";
        this.tipoMensaje = "error";
      }
    },
  },
  created: function(){
    this.getAllUsuarios();
  }
};
</script>

  
  <style scoped>
   * {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
  body {
    background-color: #F9FAFB;
  }
  .banner{
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    object-fit: cover;
    z-index: -1;
}
  
  .login-container {
    position:absolute;
    z-index: 10;
    top: 8rem;
    left: 30rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background: rgba(255, 255, 255, 0.1);
    padding: 40px;
    border:1px solid rgba(255, 255, 255, 0.4);
    border-radius: 20px;
    backdrop-filter: blur(15px);
    box-shadow: 0 25px 45px rgba(0, 0, 0, 0.4);
    width: 100%;
    max-width: 400px;
    margin: 5rem auto;
    overflow: hidden;
  }
  .login-container {
  transition: transform 0.3s ease, opacity 0.3s ease;
}

.login-container:hover {
  transform: scale(1.02);
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
  .mensaje {
  margin-bottom: 1rem;
  padding: 0.75rem;
  border-radius: 8px;
  font-size: 1rem;
  text-align: center;
  width: 100%;
}

.success {
  background-color: #d1fae5;
  color: #065f46;
  border: 1px solid #10b981;
}

.error {
  background-color: #fee2e2;
  color: #991b1b;
  border: 1px solid #ef4444;
}
  </style>
  