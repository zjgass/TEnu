

import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:44315/api'
});

export default {

  getIngredients() {
    return http.get('/ingredient');
  },

  getIngredient(ingredientId) {
    return http.get(`/ingredient/${ingredientId}`)
  },

  addIngredient(ingredient) {
    return http.post('/ingredient', ingredient);
  },

  deleteIngredient(ingredientId){
    return http.delete(`/ingredient/${ingredientId}`);
  }


}