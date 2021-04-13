<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>

  <div id='login-box'>

    <div id='username-box'>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
</div>


<div id='password-box'>
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
</div>

      <button type="submit">Sign in</button>
</div>


<div id='alernate-options'>
      <router-link id='new-account' :to="{ name: 'register' }">Need an account?</router-link>
             <button id='submit' type="submit">Sign in as guest</button> 
            </div>
    </form>




  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/home2");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>


<style scoped>

#login{
  border: 1px solid black;
  margin: 0px auto;
  width: 1000px;
  padding: 20px;
}

#login-box{
  border: 1px black solid;
  height: 100px;
  width: 40%;
  margin: 0px auto;
  padding: 10px;

  /* display: flex; */
  /* flex-direction: row; */
}

.form-control{
  /* width: 100px;
  height: 20px; */
}



#username-box, #password-box, button{
  margin-top: 10px;


}

label{
  width: 250px;
}

#alernate-options{
  /* background-color: red; */
  width: 40%;
  margin: 0px auto;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: baseline;
  padding: 10px;
  height: 60px;
}




#new-account, #submit{
margin: 0px auto;

}





</style>