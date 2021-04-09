import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:44315'
});

export default {

  getPlans() {
    return http.get('/plan');
  },

  getPlan(planId) {
    return http.get(`/plan/${planId}`)
  }
}
