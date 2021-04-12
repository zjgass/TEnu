import axios from 'axios';


const http = axios.create({
  baseURL: 'https://localhost:44315/api'
});

export default {

  getMeal() {
    return http.get('/meal');
  },

  getMeals(boardId) {
    return http.get(`/meal/${boardId}`)
  },

  createMeal(meal){
    return http.post("/meal", meal);
  },

  addRecipeToMeal(mealId, recipeId){
    return http.post(`/meal/${mealId}/add/${recipeId}`);
  }




}
