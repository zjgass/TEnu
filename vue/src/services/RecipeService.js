import axios from 'axios';

let recipePath = '/api/recipe';

export default {

  getRecipes() {
    return axios.get(recipePath);
  },

  getRecipe(recipeId) {
    return axios.get(recipePath + `/${recipeId}`)
  },

  addRecipe(recipe) {
    return axios.post(recipePath, recipe);
  },

  deleteRecipe(recipeId){
    return axios.delete(recipePath + `/${recipeId}`);
  },

  updateRecipe(recipe){
    return axios.put(recipePath + `/${recipe.recipeId}`, recipe);
  }
}

