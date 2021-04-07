import axios from 'axios';

const http = axios.create({
  baseURL: VUE_APP_REMOTE_API
});

export default {

  getRecipe() {
    return http.get('/recipe');
  },

  getRecipe(recipeId) {
    return http.get(`/recipe/${recipeId}`)
  }
}
