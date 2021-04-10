
<template>
<div>


<div id='top-of-component'>

<div id='current-plan'>
    <h1>Your Meal Plan</h1>
    <h2 id='current-plan-name'>{{Plans[dropDown-1].name}}</h2>
        <h2>current value of dropDown:  {{dropDown}}</h2>

    </div>


<form id='choose-plan' action="" method="">
<p> View A Different Meal Plan: </p>
<select name="select-plan"  v-model="dropDown" id='plan-select-dropdown'>

<option  class='plan-dropdown-item'
v-for="plan in Plans"
v-bind:key="plan.name"
v-bind:value='plan.planId'
>{{plan.name}}</option>





</select>

</form>

</div>


<div id='meal-plan'>


<div class='plan-column' id='monday-meals'>
    <h1 class='day'>Monday</h1>
    <div class='meal-card'>
        <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('monday', 'breakfast')]"/>
    </div>
    <div class='meal-card'>
        <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('monday', 'lunch')]"/>
    </div>
    <div class='meal-card'>
   <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('monday', 'dinner')]"/>
    </div>
</div>

<div class='plan-column' id='tuesday-meals'>
    <h1 class='day'>Tuesday</h1>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('tuesday', 'breakfast')]"/>
    </div>
    <div class='meal-card'>
   <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('tuesday', 'lunch')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('tuesday', 'dinner')]"/>
    </div>
</div>

<div class='plan-column' id='wednesday-meals'>
    <h1 class='day'>Wednesday</h1>
    <div class='meal-card'>
   <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('wednesday', 'breakfast')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('wednesday', 'lunch')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('wednesday', 'dinner')]"/>
    </div>
</div>

<div class='plan-column' id='thursday-meals'>
    <h1 class='day'>Thursday</h1>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('thursday', 'breakfast')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('thursday', 'lunch')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('thursday', 'dinner')]"/>
    </div>
</div>

<div class='plan-column' id='friday-meals'>
    <h1 class='day'>Friday</h1>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('friday', 'breakfast')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('friday', 'lunch')]"/>
    </div>
    <div class='meal-card'>
    <meal-card v-bind:meal="this.$store.state.currentPlan.meals[getMealIndex('friday', 'dinner')]"/>
    </div>
</div>

      <!-- <router-link  class='nav-button' v-bind:to="{ name: 'GroceryList' }" >Grocery List</router-link> -->


</div>

<router-link tag="button" id='show-grocery-list' v-bind:to="{ name: 'GroceryList' }" >Grocery List</router-link>
       
        <!-- <h2>{{Plans}}</h2>
        <h2>currentPlan: {{currentPlan}}</h2> -->



</div>
</template>

<script>
<<<<<<< HEAD

import PlanService from "../services/PlanService";
import MealCard from "../components/MealCard";

export default {
    // props: currentPlan,    

  name: "meal-plan",
  components:{
      MealCard
  },
  data() {

    return {
      Plans: [],
    currentPlan: 0,
    dropDown: null
    };
  },
  mounted: function(){
        this.dropDown = 1;
      
  },
  methods: {
    viewPlan(planId) {
      this.$router.push(`/plans/${planId}`);
    }
  },
  created() {
    PlanService.getPlans().then((response) => {
      this.Plans = response.data;
    });
  }
};

=======
import MealCard from './MealCard.vue';


export default {
  name: "plan-list-2",
  components: {
      MealCard
   
  },
  data() {
    return {
   
    };
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
      }
  },
  created() {
      this.$store.dispatch('loadPlan');
  }
};
>>>>>>> e6bb8b2e2c1e0829f8e5a17d62899245fb4589fe
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
    width: 100%;
    font-size: 20pt;
    text-transform: capitalize;
            cursor: pointer;
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
    flex-direction: row;
    justify-content: space-between;
}

#current-plan{

    width: 50%;
    height: 100px;
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