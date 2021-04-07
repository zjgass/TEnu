
<template>
<div id='meal-plan-list'>

<ul>
<li class='plan-item'>first plan week of (monday)</li>
<li class='plan-item'>next plan </li>
</ul>

</div>


</template>

<script>
// import PlanService from '../services/PlanService';
export default {
  name: "plan-list",
  data() {
    return {
      docs: []
    }
    
  }

}
</script>

<style>

.plan-item{
color: white;
font-size: 20pt;
list-style-type: none;
padding: 10px;
width: 95%;
background-color: #1789fc;
height: 30px;
border-radius: 5px;
border: 1px solid black;
cursor: pointer;
}

#meal-plan-list{
    border: 1px solid black;
    border-radius: 5px;
    background-color: #296eb4;

}

</style>