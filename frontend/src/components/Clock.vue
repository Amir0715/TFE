<template>
  <va-card>
    <div>Текущее время: {{ localeTime }}</div>
    <div>Осталось времени: {{ remaindTime }}</div> 
    <div>Всего выделено: {{ generalTime }}</div>
    <!-- {{ time.minute }} -->
  </va-card>
</template>

<script>
import moment from 'moment';

export default {
  data() {
    return {
      time: moment(),
      endTime: moment().add(30, 's')
    };
  },
  computed: {
    localeTime() {
      // Конвертируем число в строку. Для этого существуют специальные методы
      // toLocaletimeString() или toLocaleString() или toLocaleTimeString()
      // Итоговая строка будет зависеть от локализации системы пользователя.
      // Для русской локали это будет "01.02.2020",
      // для американской "2/1/2020",
      // для немецкой — "1.2.2020"
      // Вы НЕ должны устанавливать формат даты самостоятельно
      return this.time.format('H:m:s');
    },

    remaindTime() {
        return this.endTime.fromNow();
    },
  },
  created() {
    this.intervalId = setInterval(() => (this.time = moment()), 1000); // Обновляем значения не чаще раза в секунду. А то и реже.
    // this.intervalId = setInterval(() => (this.endTime = moment()), 1000); // Обновляем значения не чаще раза в секунду. А то и реже.
  },

  // Если повесили таймер, то его нужно отключать
  beforeUnmount() {
    if (this.intervalId) clearInterval(this.intervalId);
  },
};
</script>

<style>
</style>