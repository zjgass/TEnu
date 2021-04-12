import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:44315/api'
});

export default {

  getPlans() {
    return http.get('/plan');
  },

  getPlan(planId) {
    return http.get(`/plan/${planId}`)
  },
  getGroceries(planId){
    return http.get(`/plan/${planId}/groceryList`)
  },
  removeMeal(planId, mealId, mealDay, mealTime){
    return http.delete(`/plan/${planId}/delete/${mealDay}/${mealTime}/${mealId}`)
  },
  createPlan(plan){
    return http.post(`/plan`, plan)
  }
}
