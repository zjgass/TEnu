import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:44315/api'
});

export default {

  getMeals() {
    return http.get('/meal');
  },

  getMeals(boardID) {
    return http.get(`/meal/${mealId}`)
  }
}
