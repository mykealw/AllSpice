<template>
  <div class="Recipe selectable my-2">
    <img class="rp" :src="recipe.picture" alt="" />
  </div>
</template>


<script>
export default {
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.rp {
  height: 25vh;
  width: 100%;
  object-fit: cover;
  border: 3px solid black;
}

.rp2 {
}
</style>