<template>
  <v-card class="mx-auto" tile v-if="questionSet">
    <v-form ref="form">
      <v-list>
        <v-list-item
          v-for="(question, i) in questionSet.questions"
          :key="i"
        >
          <v-list-item-content>
            <question-field :question="question" :answerModel="answerModel"></question-field>
          </v-list-item-content>
        </v-list-item>
        <v-list-item>
          <div class="flex-grow-1"></div>
          <v-btn @click="submit()" color="success">Send Answers</v-btn>
        </v-list-item>
      </v-list>
    </v-form>
  </v-card>
</template>

<script>
import Vue from "vue";
import QuestionField from '@/components/QuestionField'

export default {
  components: {
    QuestionField
  },
  props: {
    questionSetId: null
  },
  data() {
    return {
      questionSet: null,
      answerModel: null
    };
  },
  methods: {
    // Answer set is much of a boilerplate, since it gets mapped to the server side model,
    // so we are mapping the answers to a plainer model
    createAnswerModel(questionSet) {
      const answerModel = {};
      for (const question of questionSet.questions) {
        if (question.options.length) {
          for (const option of question.options) {
            Vue.set(option, 'value', option.questionOptionId);
          }
          Vue.set(answerModel, question.questionId, []);
        }
      }
      return answerModel;
    },

    // Answer set model is based on question set model and the answers collected into answer model
    createAnswerSet(questionSet, answerModel) {
      const answers = [];
      const answerSet = {
        questionSetId: questionSet.questionSetId,
        answers
      };
      for (const questionId in answerModel) {
        const answer = { questionId };
        if (Array.isArray(answerModel[questionId])) {
          const questionOptions = questionSet.questions.find(q => q.questionId == questionId).options;
          const answerOptions = [];
          for (const questionOption of questionOptions) {
            if (answerModel[questionId].indexOf(questionOption.questionOptionId) > -1) {
              const answerOption = {
                questionOptionId: questionOption.questionOptionId
              };
              answerOptions.push(answerOption);
            }
          }
          answer.options = answerOptions;
        } else {
          answer.value = answerModel[questionId];
        }
        answers.push(answer);
      }
      return answerSet;
    },
    
    async loadQuestionSet(questionSetId) {
      const result = await this.$store.dispatch("questions/load", { questionSetId });
      this.questionSet = result.data;
      this.answerModel = this.createAnswerModel(this.questionSet);
    },
    
    async submit() {
      if (this.$refs.form.validate()) {
        const answerSet = this.createAnswerSet(
          this.questionSet,
          this.answerModel
        );
        await this.$store.dispatch("answers/save", { answerSet });
        this.$router.push({ name: "list-answer-sets" });
      }
    }
  },
  async mounted() {
    await Vue.nextTick();
    await this.loadQuestionSet(this.questionSetId);
    this.$emit("title-update", `Question Set - ${this.questionSet.title}`);
  }
};
</script>
