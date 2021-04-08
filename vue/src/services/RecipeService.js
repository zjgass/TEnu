import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:44315/api'
});

export default {

  getRecipes() {
    return http.get('/recipe');
  },

  getRecipe(recipeId) {
    return http.get(`/recipe/${recipeId}`)
  },

  addRecipe(recipe) {
    return http.post('/recipe', recipe);
  }


}


//https://localhost:44315/recipe
//https://localhost:44315/recipe/1