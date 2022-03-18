<template>
  <va-card stripe stripe-color="success">
    <va-card-actions align="center" vertical>
      <va-radio
        v-for="answer in answers"
        :key="answer.id"
        v-model="selectedAnswer"
        :option="answer.title"
      />
      <va-button>Сохранить</va-button>
    </va-card-actions>
  </va-card>
</template>

<script>
export default {
  name: "ListAnswers",
  data() {
    return {
      answers: [
        {
          id: 0,
          title: "Вариант А",
        },
        {
          id: 1,
          title: "Вариант B",
        },
        {
          id: 2,
          title: "Вариант C",
        },
        {
          id: 3,
          title: "Вариант D",
        },
      ],
      selectedAnswer: {},
    };
  },
};
</script>

<style>
</style>