import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:44315/api'
});

export default {

  getMeals() {
    return http.get('/meal');
  },

  getMeal(mealID) {
    return http.get(`/meal/${mealID}`)
  }
}
