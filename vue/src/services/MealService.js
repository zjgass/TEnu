import axios from 'axios';

const http = axios.create({
  baseURL: VUE_APP_REMOTE_API
});

export default {

  getMeals() {
    return http.get('/meal');
  },

  getMeals(boardID) {
    return http.get(`/meal/${mealId}`)
  }
}
