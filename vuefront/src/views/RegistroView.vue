<template>
  <div class="register-container">
    <h2 class="register-title">Registro de Usuario</h2>
    <form @submit.prevent="register">
      <label for="nombre">Nombre</label>
      <input type="text" v-model="nombre" id="nombre" placeholder="Tu nombre" required />

      <label for="apellido">Apellido</label>
      <input type="text" v-model="apellido" id="apellido" placeholder="Tu apellido" required />

      <label for="username">Usuario</label>
      <input type="text" v-model="username" id="username" placeholder="Tu nombre de usuario" required />

      <label for="password">Contraseña</label>
      <input type="password" v-model="password" id="password" placeholder="Tu contraseña" required />

      <button type="submit" class="register-btn">Registrar</button>
    </form>

    <div v-if="error" class="error-message">{{ error }}</div>
    <div v-if="success" class="success-message">{{ success }}</div>

    <div class="login-link">
      ¿Ya tienes cuenta?
      <a @click.prevent="$router.push({ name: 'loginview' })" href="#">Inicia sesión aquí</a>
    </div>
  </div>
</template>

<script>
export default {
  name: "RegisterView",
  data() {
    return {
      nombre: "",
      apellido: "",
      username: "",
      password: "",
      error: null,
    };
  },
  methods: {
    async register() {
      this.error = null;

      const newUser = {
        nombre: this.nombre,
        apellido: this.apellido,
        username: this.username,
        contraseña: this.password,
      };

      try {
        const response = await this.axios.post(
          "http://localhost:5272/api/Usuario",
          newUser
        );
        console.log(response)
        alert( "Usuario registrado correctamente");
        setTimeout(() => {
          this.$router.push({ name: "loginview" });
        }, 1500);
      } catch (err) {
        this.error =
          err.response?.data?.message || "Error al registrar usuario";
      }
    },
  },
};
</script>

<style scoped>
.register-container {
  background-color: #fff;
  padding: 2rem;
  border-radius: 1rem;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  margin: 5rem auto;
}

.register-title {
  text-align: center;
  color: #1f2937;
  font-size: 1.8rem;
  margin-bottom: 1.5rem;
}

label {
  display: block;
  color: #1f2937;
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

.register-btn {
  background-color: #ffffff;
  color: #1f2937;
  border: none;
  padding: 0.75rem;
  width: 100%;
  font-size: 1rem;
  border-radius: 0.5rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.register-btn:hover {
  background-color: #ea580c;
}

.error-message {
  color: red;
  margin-top: 0.5rem;
}

.success-message {
  color: green;
  margin-top: 0.5rem;
}

.login-link {
  text-align: center;
  margin-top: 1rem;
  font-size: 0.9rem;
}

.login-link a {
  color: #1f2937;
  text-decoration: none;
  cursor: pointer;
}

.login-link a:hover {
  text-decoration: underline;
}
</style>
