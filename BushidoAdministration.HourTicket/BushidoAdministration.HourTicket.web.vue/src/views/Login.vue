<script>
import { defineComponent } from 'vue';
import { useAuthStore } from '../stores/authStore';

export default defineComponent({
	name: 'LoginComponent',
	data() {
		return {
			username: '',
			password: '',
			remember: false,
		};
	},
	setup() {
		const authStore = useAuthStore();
		return {
			authStore,
		};
	},
	methods: {
		async login() {
			const result = await this.authStore.login(
				this.username,
				this.password,
				this.remember
			);
			if (result) {
				this.$router.push('/');
			} else {
				alert('Invalid username or password');
			}
		},
	},
	computed: {},
});
</script>

<template>
	<div
		class="bg-gray-500 flex flex-col flex-wrap justify-start ml-50 mr-50 p-10 rounded-lg"
	>
		<!--//Header-->
		<h1 class="text-xl">Entra in Segna Ore - Bushido Karate</h1>

		<!--//FORM-->
		<form @submit="login" class="mt-5">
			<!--//USERNAME-->
			<div class="mb-6">
				<label
					for="username"
					class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300"
				>
					email
				</label>
				<input
					type="username"
					id="username"
					v-model="username"
					class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
					placeholder="Insert email"
				/>
			</div>

			<!--//PASSWORD-->
			<div class="mb-6">
				<label
					for="password"
					class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300"
				>
					Password
				</label>
				<input
					type="password"
					id="password"
					v-model="password"
					class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
					placeholder="Insert password"
				/>
			</div>

			<!--//REMEMBER ME-->
			<div class="flex items-start mb-6">
				<div class="flex items-center h-5">
					<input
						id="remember"
						type="checkbox"
						v-model="remember"
						class="w-4 h-4 bg-gray-50 rounded border border-gray-300 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800"
					/>
				</div>
				<label
					for="remember"
					class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300"
					>Remember me</label
				>
			</div>

			<!--BUTTON-->
			<button
				type="submit"
				class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
			>
				Submit
			</button>
		</form>
	</div>
</template>

<style></style>
