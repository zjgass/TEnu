
<template>
<div>


<div id='top-of-component'>

<div id='current-plan'>
    <h1>Your Meal Plan</h1>
    <h2>*name of current selected plan</h2>

    </div>


<form id='choose-plan' action="" method="">
<p> View A Different Meal Plan: </p>
<select name="select-plan">
<option value=""> select plan </option>
<option value=""> plan name </option>
<option value=""> plan name </option>
<option value=""> plan name </option>
<option value=""> plan name </option>
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


</div>
</div>
</template>

<script>
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


#choose-plan, #current-plan{
    margin: 10px;
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

.meal-card h2{


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