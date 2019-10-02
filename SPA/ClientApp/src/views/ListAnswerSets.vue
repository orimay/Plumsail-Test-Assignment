<template>
  <div>
    <v-text-field
      outlined
      label="Case-sensitive Value Search"
      append-icon="fa-search"
      v-model="searchValue"
      @keyup="searchAnswers()"
    ></v-text-field>
    <div v-if="!answerModels.length">
      No answers found
    </div>
    <v-card
      v-for="(answerModel, i) in answerModels"
      :key="i"
      class="mx-auto mb-5"
    >
      <v-card-title>
        {{ answerModel.title }}
        <div class="flex-grow-1"></div>
        {{ answerModel.createdDate | moment("YYYY-MM-DD hh:mm") }}
      </v-card-title>
      <v-list-item
        v-for="(answer, j) in answerModel.answers"
        :key="j"
        v-if="!answer.options || answer.options.length"
        two-line
        class="mb-2"
      >
        <v-list-item-content>
          <v-list-item-subtitle class="headline">{{ answer.question }}</v-list-item-subtitle>
          <div class="grey--text subtitle-1 mx-1">
            <div v-if="answer.options">
              <div v-for="(option, k) in answer.options" :key="k">
                {{ option }}
              </div>
            </div>
            <div v-else>
              {{ answer.value }}
            </div>
          </div>
        </v-list-item-content>
      </v-list-item>
    </v-card>
  </div>
</template>

<script>
import _ from 'lodash';

export default {
  data() {
    return {
      answerModels: [],
      searchValue: ""
    };
  },
  computed: {
    questionSets() {
      return this.$store.state["questions"].sets;
    },
    answerSets() {
      return this.$store.state["answers"].sets;
    }
  },
  methods: {
     
    getQuestionSet(questionSetId) {
      return this.questionSets.find(qs => qs.questionSetId == questionSetId);
    },
    
    getQuestion(questionSet, questionId) {
      return questionSet.questions.find(q => q.questionId == questionId);
    },
    
    getQuestionOption(options, questionOptionId) {
      return options.find(o => o.questionOptionId == questionOptionId);
    },
    
    // Here we create answer models, that include questions and answers text to display
    createAnswerModels(questionSets, answerSets) {
      const answerModels = [];
      for (const answerSet of answerSets) {
        const questionSet = this.getQuestionSet(answerSet.questionSetId)
        const answers = []
        const answerModel = {
          title: questionSet.title,
          createdDate: new Date(answerSet.createdDate),
          answers
        };
        for (const answer of answerSet.answers) {
          const question = this.getQuestion(questionSet, answer.questionId);
          if (question.options.length) {
            answers.push({
              question: question.label,
              options: answer.options.map(o => this.getQuestionOption(question.options, o.questionOptionId).text)
            });
          } else {
            answers.push({
              question: question.label,
              value: answer.value
            });
          }
        }
        answerModels.push(answerModel);
      }
      return answerModels;
    },
    
    async loadQuestions() {
      await this.$store.dispatch("questions/load");
    },
    
    async loadAnswers() {
      await this.$store.dispatch("answers/load", { searchValue: this.searchValue });
      this.answerModels = this.createAnswerModels(this.questionSets, this.answerSets);
    },
    
    searchAnswers: _.debounce(function () { this.loadAnswers() }, 500)

  },
  mounted() {
    this.loadQuestions();
    this.loadAnswers();
    this.$emit("title-update", `Answer Sets`);
  }
};
</script>
