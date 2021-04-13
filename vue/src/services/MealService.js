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
    return axios.post(mealPath + `/${mealId}/add/${recipeId}`);
  }




}
