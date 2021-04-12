import axios from 'axios';


let mealPath = '/api/meal';

export default {

  getMeal() {
    return axios.get(mealPath);
  },

  getMeals(boardId) {
    return axios.get(mealPath + `/${boardId}`)
  },

  createMeal(meal){
    return axios.post(mealPath, meal);
  },

  addRecipeToMeal(mealId, recipeId){
<<<<<<< HEAD
    return http.post(`/meal/${mealId}/add/${recipeId}`);
  },

  deleteRecipeFromMeal(mealId, recipeId){
    return http.delete(`/meal/${mealId}/delete/${recipeId}`);
=======
    return axios.post(mealPath + `/${mealId}/add/${recipeId}`);
>>>>>>> 0b194522c1fb48b991dc9b1df6d7e7058f14bfe6
  }




}
