<template>
    <div id='detail-box'>
        
        <div id='recipe-box'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <h2>serves: {{recipe.serves}}</h2>
        <h2>prep time: {{recipe.prepTime}}</h2>
        <h2>cook time: {{recipe.cookTime}}</h2>
        <h2>total time: {{recipe.totalTime}}</h2>
        <h2>ingredients:</h2>
        <ul>
            <li v-for="item in recipe.ingredients" :key="item" >{{ item.name }} Qty: {{item.qty}} {{item.unit}}</li>
        </ul>
        <h2>utensils: </h2>
            <!-- <li v-for="item in recipe.utensils" :key="item"> {{item}}</li> -->
            <p>{{recipe.utensils}}</p>
        <h2>instructions:</h2>
        <p>{{recipe.instructions}}</p>
        </div>

      <!-- <tr v-for="recipe in Recipes" :key="recipe.recipeId" > -->

<div id='image-box'>
    <img src="recipe.imgUrl" alt='image of completed recipe' />




    </div>

<!-- <p>{{recipe}}</p> -->
    </div>






</template>


<script>
import recipeService from '@/services/RecipeService';

export default {
    name: 'recipe-detail',
    props: {
        'recipeId' : Number
    },
    data(){
        return {
            recipe: []
           
        }
    },
    computed: {
   
    },
    created() {
        recipeService.getRecipe(this.$route.params.id)
                    .then(response => {
                    this.recipe =  response.data;
            });
    }

}


</script>

<style scoped>

#recipe-title{
text-decoration: underline;
margin-top: 0px;
text-transform: capitalize;

}

#recipe-box, #image-box{
    /* border: 1px solid black; */
    width: 45%;
    padding: 10px;
    border-radius: 5px;
      box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 5px;
    height: 600px;

}
#detail-box{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    height: 600px;


}
#image-box{
    height: 50%;
        height: 600px;
}





</style>