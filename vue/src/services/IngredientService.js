import axios from 'axios';

let ingredientPath = '/api/ingredient';

export default {

  getIngredients() {
    return axios.get(ingredientPath);
  },

  getIngredient(ingredientId) {
    return axios.get(ingredientPath + `/${ingredientId}`)
  },

  addIngredient(ingredient) {
    return axios.post(ingredientPath, ingredient);
  },

  deleteIngredient(ingredientId){
    return axios.delete(ingredientPath + `/${ingredientId}`);
  }


}