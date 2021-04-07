
<template>
<div id='meals'>

<ul>
<li class='plan-item'>Week of (monday)</li>
<li class='plan-item'>week of next week </li>
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

list-style-type: none;
margin: 0px auto 10px;
padding: 10px;
width: 900px;
background-color: #1789fc;
height: 30px;
border-radius: 5px;
border: 1px solid black;

}

#meals{
    border: 1px solid black;
    border-radius: 5px;

}

</style>