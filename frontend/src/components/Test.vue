<template>
  <div class="body">
    <div class="clock">
      <clock />
    </div>
    <div class="right">
      <question-title class="question" />
      <list-answers class="answers" />
    </div>
  </div>
</template>
<script>
import Clock from './Clock.vue'
import ListAnswers from './ListAnswers.vue'
import QuestionTitle from './QuestionTitle.vue'
// Это тест - он должен состоять из вопросов
export default {
  components: { ListAnswers, QuestionTitle, Clock },
  name: "test"
}
</script>

<style scoped>

.body {
  display: flex;
  margin: 10px;
}

.clock {
  display: block;
  width: 40%;
  height: 40%;
}

.right {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
}

.question {
  flex-shrink: 2;
  flex-grow: 0;
  margin-right: 20px;
}
</style>