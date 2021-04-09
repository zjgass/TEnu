<template>
    <div class="meal-card-component">
        
            <p>{{this.Meals.name}}</p>



    </div>
</template>


<script>
import MealService from "../services/MealService";



export default {
  name: "meal-card",
  components: {

  } ,
  data() {
    return {
      Meals: []
    }
  },
  created() {
    MealService.getMeal(1).then((response) => {
      this.Meals = response.data;
    });
  }
};

</script>







<style scoped>

.meal-card{
    background-color: white;
}


</style>

