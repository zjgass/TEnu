<template>
    <div class="meal-card">
       
         
        <div v-if='hasMeal'>
            <router-link  v-bind:to="{ name: 'AddMeal', params: {id : meal.mealId} }">
            <div class="meal-body">  
              <h3 id='meal-name'>{{meal.name}}</h3> 
              <h3 id='total-time'> Total Time: {{meal.totalTime}}</h3> 

              
              <!-- <div class="recipe-list">
                    <h3>Includes these recipes: </h3>
                    <h3 v-for="recipe in meal.recipeList" v-bind:key="recipe.recipeId">{{recipe.name}}</h3>   
              </div>

              -->


  

              <div class='delete-prompt' v-show='deletePromptDiv'>
                    <h3>Do you wish to remove this meal?</h3>
                    <button v-on:click.prevent='deleteThisMeal()'>Yes</button>
                    <button v-on:click.prevent='removePrompt()'>No</button>
              </div>
              <div class="buttons" v-on:click.prevent="deletePrompt()">
                    <svg  xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                    <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                    </svg>
              </div>
            </div>
            </router-link>
        </div>
        <router-link v-bind:to="{ name: 'AddMeal', params: {mealTime: mealTime, mealDay: mealDay } }">
        <div class="empty-meal" v-if='!hasMeal'>
            <p>ADD {{mealDay}} {{mealTime}}</p>
        </div>
        </router-link>



    </div>
   



</template>

<script>

import planService from "../services/PlanService";

export default {
    name: 'meal-card',
    props: {
        meal : Object,
        mealTime : String,
        mealDay : String
        },
    
    data() {

        return{
            deletePromptDiv: false
        }
    },
    computed: {
        hasMeal() {
            if(!this.meal){
                return false;
            }
            return true;
        }
    },
    methods: {
        deletePrompt(){
            this.deletePromptDiv = true;
        },
        removePrompt() {
            this.deletePromptDiv = false;
        },
        deleteThisMeal() {
            this.deletePromptDiv = false;
            planService.removeMeal(this.$store.state.currentPlanId, 
                                    this.meal.mealId,
                                    this.mealDay,
                                    this.mealTime);      
        }

    }


}
</script>



<style scoped>



.meal-card{
  display: flex;
  flex-direction: column;
  align-items: left;
  justify-content:  flex-start;
  box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 7px;
  text-decoration-line: none !important;

  margin: 5px 10px 5px 10px;
  padding: 0px 0px 0px 0px;

      background-color: rgb(178, 226, 186);
}


.meal-card:hover{
    background-color: rgb(144, 218, 157);
}




.recipe-list h3{
    font-size: 1rem;
    text-decoration-line: none;
    text-decoration: none;
}

.delete-prompt {
    position:relative;
    left: 30px;
    float:inline-start;
    margin: 25px 0px 25px 0px;
    height: 100px;
    width: 150px;
    background-color: black;
}

.delete-prompt h3{
    color: white;
    font-size: .8rem;
}

#meal-name{
    font-size: 1.2rem;
    text-transform: capitalize;
    margin-top: 10px;

}

#total-time{
    font-size: 1rem;

}


#meal-card-router-link, #add-meal-router-link{
            text-decoration: none;
            color: black;
            font-family: 'Courier New', Courier, monospace;
            font-size: 1rem;
}

.meal-body{
    display:flex;
    flex-direction: column;
    justify-content: flex-start;
    align-content: flex-start;
    margin: 5px 0px 0px 0px;

}

/*override vues crummy formatting for router links with this */
a:-webkit-any-link{
    text-decoration-color: black;
    text-decoration: none;
    color: black;
}



#total-time{
    margin-top: 0px;
}
</style>

