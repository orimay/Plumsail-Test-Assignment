import InputTypes from "./input-types";
import ValidatorTypes from './validator-types';

const questionSet1 = {
  title: "Fruits",
  questions: [
    {
      inputType: InputTypes.RADIO_BUTTONS,
      label: "Do you like apples?",
      options: [
        { text: "Yes"},
        { text: "No"}
      ],
      validators: [
        {
          validatorType: ValidatorTypes.REQUIRED,
          arguments: [
            { value: "You must answer the question" }
          ]
        }
      ]
    },
    {
      inputType: InputTypes.CHECKBOXES,
      label: "Which other fruits do you like?",
      options: [
        { text: "Bananas"},
        { text: "Peaches"},
        { text: "Pineapples"},
        { text: "Oranges"}
      ],
      validators: [
        {
          validatorType: ValidatorTypes.REQUIRED,
          arguments: [
            { value: "You must peek at leat one option" }
          ]
        }
      ]
    }
  ]
};

const questionSet2 = {
  title: "Books",
  questions: [
    {
      inputType: InputTypes.TEXT_INPUT,
      label: "What is your name?",
      validators: [
        {
          validatorType: ValidatorTypes.REQUIRED,
          arguments: [
            { value: "Name is required" }
          ]
        },
        {
          validatorType: ValidatorTypes.MIN_LENGTH,
          arguments: [
            { value: 2 },
            { value: "Name must be at least 2 characters long" }
          ]
        }
      ]
    },
    {
      inputType: InputTypes.DATE,
      label: "When were you born?",
      validators: [
        {
          validatorType: ValidatorTypes.REQUIRED,
          arguments: [
            { value: "Please pick your birthday" }
          ]
        },
        {
          validatorType: ValidatorTypes.MIN_YEARS_AGO,
          arguments: [
            { value: 1 },
            { value: "We doubt you were born later than a year ago" }
          ]
        }
      ]
    },
    {
      inputType: InputTypes.TEXT_INPUT,
      label: "What is your favourite book?"
    },
    {
      inputType: InputTypes.TEXTAREA,
      label: "Tell about it"
    },
    {
      inputType: InputTypes.DROPDOWN,
      label: "How far have you read 'Harry Potter and the methods of rationality'?",
      options: [
        { text: "0%"},
        { text: "25%"},
        { text: "50%"},
        { text: "75%"},
        { text: "100%"}
      ],
      validators: [
        {
          validatorType: ValidatorTypes.REQUIRED,
          arguments: [
            { value: "This field is mandatory" }
          ]
        }
      ]
    }
  ]
};

export default [
  questionSet1,
  questionSet2
];
