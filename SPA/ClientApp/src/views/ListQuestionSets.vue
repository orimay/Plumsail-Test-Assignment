<template>
  <v-card class="mx-auto" tile>
    <div v-if="!questionSets.length">
      Loading question sets...
    </div>
    <v-list v-else>
      <v-list-item
        v-for="(questionSet, i) in questionSets"
        :key="i"
        :to="{ name: 'question-set', params: { questionSetId: questionSet.questionSetId }}"
      >
        <v-list-item-title v-html="questionSet.title"></v-list-item-title>
        <v-list-item-subtitle>{{ questionSet.questions.length }} questions</v-list-item-subtitle>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script>
export default {
  computed: {
    questionSets() {
      return this.$store.state["questions"].sets;
    }
  },
  methods: {
    
    async mockQuestions() {
      await this.$store.dispatch("questions/load");
      if (!this.questionSets.length) {
        await this.$store.dispatch("questions/mock");
        console.log(await this.$store.dispatch("questions/load"));
      }
    }

  },
  mounted() {
    this.$emit("title-update", "Question Sets");
    this.mockQuestions();
  }
};
</script>
