import axios from 'axios';

const http = axios.create({
  baseURL: VUE_APP_REMOTE_API
});

export default {

  getPlans() {
    return http.get('/plan');
  },

  getPlan(planId) {
    return http.get(`/plan/${planId}`)
  }
}
