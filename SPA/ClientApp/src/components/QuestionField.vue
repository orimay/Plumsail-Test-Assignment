<template>
  <div v-if="question.inputType == InputTypes.TEXT_INPUT">
    <v-text-field
      :label="question.label"
      :rules="createValidationRules(question)"
      v-model="answerModel[question.questionId]"
    ></v-text-field>
  </div>
  
  <div v-else-if="question.inputType == InputTypes.TEXTAREA">
    <v-textarea
      :label="question.label"
      :rules="createValidationRules(question)"
      v-model="answerModel[question.questionId]"
    ></v-textarea>
  </div>
  
  <div v-else-if="question.inputType == InputTypes.RADIO_BUTTONS">
    <v-radio-group
      :label="question.label"
      :rules="createValidationRules(question)"
      v-model="answerModel[question.questionId][0]"
    >
      <v-radio
        v-for="(option, j) in question.options"
        :key="j"
        :label="option.text"
        :value="option.questionOptionId"
      ></v-radio>
    </v-radio-group>
  </div>
  
  <div v-else-if="question.inputType == InputTypes.CHECKBOXES">
    <v-list-item-title v-text="question.label"></v-list-item-title>
    <v-checkbox
      v-for="(option, j) in question.options"
      :key="j"
      :label="option.text"
      :value="option.value"
      :rules="createValidationRules(question)"
      v-model="answerModel[question.questionId]"
      :hide-details="j < question.options.length - 1"
    ></v-checkbox>
  </div>

  <div v-else-if="question.inputType == InputTypes.DROPDOWN">
    <v-select
      :items="question.options"
      :label="question.label"
      :rules="createValidationRules(question)"
      v-model="answerModel[question.questionId][0]"
    ></v-select>
  </div>

  <div v-else-if="question.inputType == InputTypes.DATE">
    <v-menu
      :ref="`menu_${question.questionId}`"
      v-model="menues[question.questionId]"
      :close-on-content-click="false"
      :return-value.sync="answerModel[question.questionId]"
      transition="scale-transition"
      offset-y
      min-width="290px"
    >
      <template v-slot:activator="{ on }">
        <v-text-field
          v-model="answerModel[question.questionId]"
          :label="question.label"
          :rules="createValidationRules(question)"
          readonly
          v-on="on"
        ></v-text-field>
      </template>
      <v-date-picker v-model="answerModel[question.questionId]" no-title scrollable>
        <div class="flex-grow-1"></div>
        <v-btn text color="primary" @click="menu = false">Cancel</v-btn>
        <v-btn text color="primary" @click="$refs[`menu_${question.questionId}`].save(answerModel[question.questionId])">OK</v-btn>
      </v-date-picker>
    </v-menu>
  </div>

  <!-- <div v-else>
    <v-list-item-title v-text="question.label"></v-list-item-title>
  </div> -->
  
</template>

<script>
import InputTypes from "@/constants/input-types";
import Validators from "@/constants/validators";

export default {
  name: "QuestionField",
  props: {
    question: Object,
    answerModel: Object
  },
  data() {
    return {
      InputTypes,
      menues: {}
    }
  },
  methods: {
    createValidationRules() {
      const rules = [];
      if (this.question.validators) {
        for (const validator of this.question.validators) {
          rules.push(
            Validators[validator.validatorType](
              ...validator.arguments.map(a => a.value)
            )
          );
        }
      }
      return rules;
    }
  }
};
</script>
