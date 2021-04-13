import axios from 'axios';

let recipePath = '/api/recipe';

export default {

  getRecipes() {
    return axios.get(recipePath);
  },
  getPublicRecipes(){
    return axios.get(recipePath + `/public`)
  },
  getRecipe(recipeId) {
    return axios.get(recipePath + `/${recipeId}`)
  },

  addRecipe(recipe) {
    return axios.post(recipePath, recipe);
  },

  deleteRecipe(recipeId){
    return axios.delete(recipePath + `/${recipeId}`);
  }
}

