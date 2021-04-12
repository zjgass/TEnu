
import axios from 'axios';

let planPath = '/api/plan';

export default {

  getPlans() {
    return axios.get(planPath);
  },

  getPlan(planId) {
    return axios.get(planPath + `/${planId}`)
  },
  getGroceries(planId){
    return axios.get(planPath + `/${planId}/groceryList`)
  },
  removeMeal(planId, mealId, mealDay, mealTime){
    return axios.delete(planPath + `/${planId}/delete/${mealDay}/${mealTime}/${mealId}`)
  },
  createPlan(plan){
    return axios.post(planPath, plan)
  },
  addMeal(planId, mealDay, mealTime, mealId){
    return axios.post(planPath + `/${planId}/add/${mealDay}/${mealTime}/${mealId}`)
  }
}
