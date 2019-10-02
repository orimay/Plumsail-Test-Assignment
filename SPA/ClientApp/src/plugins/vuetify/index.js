import Vue from "vue";
import Vuetify , {
  VApp,
  VContainer,
  VCard,
  VCardTitle,
  VList,
  VListItem,
  VListItemTitle,
  VListItemSubtitle,
  VListItemContent,
  VToolbarTitle,
  VAppBar,
  VForm,
  VTextField,
  VTextarea,
  VRadio,
  VRadioGroup,
  VCheckbox,
  VSelect,
  VBtn,
  VMenu,
  VDatePicker,
  VToolbarItems
} from 'vuetify/lib';
import '@fortawesome/fontawesome-free/css/all.css'

Vue.use(Vuetify, {
  components: {
    VApp,
    VContainer,
    VCard,
    VCardTitle,
    VList,
    VListItem,
    VListItemTitle,
    VListItemSubtitle,
    VListItemContent,
    VToolbarTitle,
    VAppBar,
    VForm,
    VTextField,
    VTextarea,
    VRadio,
    VRadioGroup,
    VCheckbox,
    VSelect,
    VBtn,
    VMenu,
    VDatePicker,
    VToolbarItems
  }
});

export default new Vuetify({
  icons: {
    iconfont: 'fa'
  }
});
