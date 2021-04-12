
<template>

    <div id='top-of-component'> 

        <!-- <div id='current-plan'>
            <h1>Your Meal Plan</h1>
        </div>  -->

        <div class='select-plan-container' >
         
            <p> Select Plan: </p>
            <select name="select-plan"  v-model="currentPlanId" v-on:change.prevent='changePlan()' id='plan-select-dropdown'>

                <option  class='plan-dropdown-item'
                  v-for="plan in this.$store.state.userPlanList"
                  v-bind:key="plan.name"
                  v-bind:value='plan.planId'
                  >{{plan.name}}</option> 

            </select>
    
            <div v-if="enterNewPlanName">
                <input class="new-plan" name="new-plan-name" type="text" v-model="plan.name" placeholder="Name for the new Plan" id='new-plan-name'/>
                <button class="new-plan" name="save-new-plan-name" v-on:click.prevent='saveNewPlanName()' id='new-plan-save-button'> Save Plan </button>
            </div>
            <button v-else class="new-plan" name="new-plan" v-on:click.prevent='createNewPlan()' id='new-plan-button'> New Plan </button>
        
        </div>

   

        <div id='meal-plan'>

            <div class='plan-column' id='monday-meals'>
                 <h1 class='day'>Monday</h1>
                 <div class='meal-card'>
                 <meal-card mealTime="breakfast" mealDay="monday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('monday', 'breakfast')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="lunch" mealDay="monday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('monday', 'lunch')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="dinner" mealDay="monday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('monday', 'dinner')]"/>
                </div>
            </div>

            <div class='plan-column' id='tuesday-meals'>
                <h1 class='day'>Tuesday</h1>
                <div class='meal-card'>
                    <meal-card mealTime="breakfast" mealDay="tuesday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('tuesday', 'breakfast')]"/>
                </div>
                <div class='meal-card'>
                 <meal-card mealTime="lunch" mealDay="tuesday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('tuesday', 'lunch')]"/>
                </div>
                <div class='meal-card'>
                 <meal-card mealTime="dinner" mealDay="tuesday"  v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('tuesday', 'dinner')]"/>
                </div>
            </div>

            <div class='plan-column' id='wednesday-meals'>
                <h1 class='day'>Wednesday</h1>
                <div class='meal-card'>
                    <meal-card mealTime="breakfast" mealDay="wednesday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('wednesday', 'breakfast')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="lunch" mealDay="wednesday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('wednesday', 'lunch')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="dinner" mealDay="wednesday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('wednesday', 'dinner')]"/>
                </div>
            </div>

            <div class='plan-column' id='thursday-meals'>
                <h1 class='day'>Thursday</h1>
                <div class='meal-card'>
                    <meal-card mealTime="breakfast" mealDay="thursday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('thursday', 'breakfast')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="lunch" mealDay="thursday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('thursday', 'lunch')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="dinner" mealDay="thursday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('thursday', 'dinner')]"/>
                </div>
            </div>

            <div class='plan-column' id='friday-meals'>
                <h1 class='day'>Friday</h1>
                <div class='meal-card'>
                    <meal-card mealTime="breakfast" mealDay="friday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('friday', 'breakfast')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="lunch" mealDay="friday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('friday', 'lunch')]"/>
                </div>
                <div class='meal-card'>
                    <meal-card mealTime="dinner" mealDay="friday" v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('friday', 'dinner')]"/>
                </div>
            </div>
        </div>
      <!-- <router-link  class='nav-button' v-bind:to="{ name: 'GroceryList' }" >Grocery List</router-link> -->
        <router-link tag="button" id='show-grocery-list' v-bind:to="{ name: 'GroceryList' }" >Grocery List</router-link>

    </div>

</template>
       
        <!-- <h2>{{Plans}}</h2>
        <h2>currentPlan: {{currentPlan}}</h2> -->



<script>


import MealCard from "../components/MealCard";
import PlanService from '../services/PlanService';

export default {

  name: "plan-list-2",
  components: {
      MealCard
   
  },
  data() {

    return {
   // Plans: [],
        currentPlanId: 1,
        enterNewPlanName: false,
        //newPlanName: "",
        plan: {
            name : ""
        }
    };
  },
  
  mounted(){
       this.$store.dispatch('loadPlanList'); 
       
  },
  methods: {
   
     getMealIndex(day, time){
          let found = this.$store.state.currentPlan.meals.findIndex(element => {
              if(element.mealDay == day && element.mealTime == time){
                  return element;
              }
              return false;
          })

          return found;
      },
      changePlan(){
          this.$store.commit("SET_CURRENT_PLAN_ID", this.currentPlanId)
          this.$store.dispatch('loadPlan', this.$store.state.currentPlanId)
      },
      createNewPlan(){
          this.enterNewPlanName = true;
      },
      
      saveNewPlanName(){
          PlanService.createPlan(this.plan)
            .then(response => {
                if(response.status === 201){
                    console.log('plan created succesfully');
                }
            })
            .catch(error => {
                if(error.response) {
                    console.log('error saving recipe')
                    this.errorMsg = "Error creating new Recipe. Response received was '" + error.response.statusText + "'.";
                }
            })

            
          this.changePlan();
          this.enterNewPlanName = false;
          this.newPlanName = "";
          
      }
  },
  created() {
    this.$store.dispatch('loadPlan', this.currentPlanId);
  }
};


</script>

<style>

.plan-item{
color: white;

list-style-type: none;
margin: 0px auto 10px;
padding: 10px;
width: 900px;
background-color: #1789fc;
height: 30px;

border: 1px solid black;

}

#meal-plan{
    /* border: 1px solid black; */

    min-height: 400px;

    display:flex;
    flex-direction: row;
    justify-content: space-around;

}
.plan-column{
/* background-color: silver; */
width: 100%;
text-align: center;

padding: 20px;
    /* background-color: limegreen; */
}

.plan-column:not(:first-of-type){

    border-left: 1px solid black;
}

#current-plan, h1{

    margin-top: 0px;
}

#plan-select-dropdown{
    margin-top: 20px;
    margin-left: 10px;
    width: 50%;
    height: 30px;
    font-size: 1.2rem;
    text-transform: capitalize;
            cursor: pointer;
}

.new-plan{
    margin-top: 20px;
    margin-left: 10px;
    height: 30px;
    font-size: 1.2rem;
}

.select-plan-container{
    display: flex;
    flex-direction: row;
    align-content:stretch;
}

.plan-column h1{
    margin-top: 0px;
    text-decoration: underline;
        background-color: darkcyan;
    height: 45px;
    color: white;

    
}
#top-of-component{
    /* border: 1px solid black; */
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}

#current-plan{

    width: 50%;
    
}

#current-plan-name{
    text-transform: capitalize;
    font-size: 20pt;
}


#choose-plan, #current-plan{
    margin: 10px;
    
    
}

#choose-plan p{
        font-size: 20pt;

}


.inner-column{
    height: auto;
 
}

.meal-card{
    margin-top: 5px;
    margin-bottom: 10px;
}

.meal-card h2{
margin-bottom: 0px;

}



#show-grocery-list{
    font-size: 20pt;
    margin-top: 50px;
    cursor: pointer;
    margin-left: 20px;
}






@media(max-width: 1400px) {
#meal-plan{
    flex-direction: column;
    width: 90%;
}

.plan-column:not(:first-of-type){
border: none;
   
}

}




</style>