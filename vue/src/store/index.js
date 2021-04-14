import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'


Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token');
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

import planService from "../services/PlanService";

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    existingIngredients: [],
    newIngredients: [],
    newMealRecipes: [],
    userPlanList: [],
    currentPlanId: 1,
    currentPlan: [],
 
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    SET_CURRENT_PLAN(state, plan){
      state.currentPlan = plan;
    }, 
    SET_CURRENT_PLAN_ID(state, id){
      state.currentPlanId = id;
    },
    SET_PLAN_LIST(state, planList){
      state.userPlanList = planList;
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    ADD_INGREDIENTS(state, ingredient){
      state.existingIngredients = ingredient;
    },
    ADD_RECIPE_TO_MEAL(state, recipeId){
      state.newMealRecipes.unshift(recipeId);
    },
    STORE_MEAL_RECIPES(state, recipeList){
      state.newMealRecipes = recipeList;
    },
    REMOVE_MEAL_FROM_PLAN(state, day, mealTime){
      let found = state.currentPlan.meals.findIndex(element => {
          if(element.mealDay == day && element.mealTime == mealTime){
            return element;
          }
        return false;
        })
        console.log(`${day}, ${mealTime}, ${found}`);
      
      state.currentPlan.meals.splice(found,1);
    }
   

  },
  actions: {
        loadPlan (context, planId) {
          console.log('loadplan executed');
          console.log('planId passed = ' + planId);
          planService.getPlan(planId)
          .then(response => {
              context.commit("SET_CURRENT_PLAN", response.data)
              if(response.status === 200){
                  console.log('plan loaded');
              }
          })
          .catch(error => {
              if(error.response) {
                  this.errorMsg = "Error loading plan. Response received was '" + error.response.statusText + "'.";
              }
          })


          context.commit()
        },
        loadPlanList(context) {
          planService.getPlans()
          .then(response => {
            context.commit("SET_PLAN_LIST", response.data)
            if(response.status === 200){
              console.log('plan list loaded');
            }
          })
          .catch(error => {
            if(error.response) {
              this.errorMsg = "Error loading plan lists. Response received was '" + error.response.statusText + "'.";
            }
          })
        }


  },
  modules: {}
})
