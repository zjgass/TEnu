<template>
    <div id='detail-box'>
        
        <div id='recipe-box'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <h2>serves: {{recipe.serves}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.name"/>
        <h2>prep time: {{recipe.prepTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.prepTime"/>
        <h2>cook time: {{recipe.cookTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.cookTime"/>
        <h2>total time: {{recipe.totalTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.totalTime"/>
        <h2>ingredients:</h2>
        <ul>
            <!--<li v-for="item in recipe.ingredients" :key="item" >{{ item.name }} Qty: {{item.qty}} {{item.unit}}</li>-->
        </ul>
        <h2>utensils: </h2>
            <!--<li v-for="item in recipe.utensils" :key="item"> {{item}}</li>-->
        <h2>instructions: {{recipe.instructions}}</h2>
        </div>

      <!-- <tr v-for="recipe in Recipes" :key="recipe.recipeId" > -->
<div id='image-box'>
    <img src="recipe.imgUrl" alt='image of completed recipe' />




    </div>


    </div>
</template>


<script>
import recipeService from '@/services/RecipeService';

export default {
    name: 'recipe-edit',
    data(){
        return {
            recipe: []
           
        }
    },
    computed: {
   
    },
    created() {
        console.log("Started loading recipe to edit.")
        recipeService.getRecipe(this.$route.params.idedit)
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

}
#detail-box{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    height: 600px;
}
#image-box{
    height: 50%;
}
</style>