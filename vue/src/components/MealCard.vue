<template>
    <div class="meal-card">

         
        <div v-if='hasMeal'>
            <router-link v-bind:to="{ name: 'ViewMeal', params: {id : meal.mealId} }">
            <div class="meal-body">  
              <h3 id='meal-name'>{{meal.name}}</h3> 
              <div class="recipe-list">
                    <h3>Includes these recipes: </h3>
                    <h3 v-for="recipe in meal.recipeList" v-bind:key="recipe.recipeId">{{recipe.name}}</h3>   
              </div>
            </div>
            </router-link>
        </div>
        <router-link v-bind:to="{ name: 'AddMeal' }">
        <div class="empty-meal" v-if='!hasMeal'>
            <p>HELLO GIVE ME MEAL</p>
        </div>
        </router-link>

    </div>
   



</template>

<script>


export default {
    name: 'meal-card',
    props: ["meal"],
    data() {

        return{
            

        }
    },
    computed: {
        hasMeal() {
            if(!this.meal){
                return false;
            }
            return true;
        }
    }


}
</script>



<style scoped>



.meal-card{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center flex-start;
  box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  
 
  margin: 5px 10px 5px 10px;
  padding: 0px 0px 0px 0px;
}
.recipe-list>h3{
    font-size: 1rem;
}

#meal-name{
    font-size: 1rem;
}



</style>

