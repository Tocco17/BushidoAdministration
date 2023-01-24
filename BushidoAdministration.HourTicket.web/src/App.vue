<script>
import { defineComponent } from 'vue';
import { useAuthStore } from './stores/authStore';

export default defineComponent({
	data() {
		return {
			navbarOpened: false,
		};
	},
	setup() {
		const authStore = useAuthStore();
		return {
			authStore,
		};
	},
	methods: {
		logout() {
			console.log('Logout clicked');
			this.authStore.logout();
		},
		isCurrentPage(path) {
			return path === this.$route.path;
		},
		activePage(path) {
			if (this.isCurrentPage(path)) return 'text-purple-500';
		},
		checkAuthorization(path) {
			// console.log(this.$route);
			console.log(this.$router);
			console.log(this.$router.getRoutes());
			const routerPath = this.$router
				.getRoutes()
				.find((r) => r.path === path);
			return !routerPath.meta.requiresAdmin;
		},
	},
	computed: {
		pageClass() {
			if (this.isCurrentPage('/login'))
				return 'flex flex-row flex-wrap justify-center content-start';

			// if (this.isCurrentPage('/Articles'))
			// 	return 'flex flex-col flex-wrap justify-start';
		},
	},
});
</script>

<template>
	<header>
		<nav
			class="flex flex-wrap items-center justify-between w-full py-4 md:py-0 px-4 text-4xl text-gray-700 bg-gray-500"
		>
			<div>
				<router-link to="/">Segna Ore - Bushido Karate</router-link>
			</div>

			<svg
				xmlns="http://www.w3.org/2000/svg"
				id="menu-button"
				class="h-6 w-6 cursor-pointer md:hidden block"
				fill="none"
				viewBox="0 0 24 24"
				stroke="currentColor"
				@click="navbarOpened = !navbarOpened"
			>
				<path
					stroke-linecap="round"
					stroke-linejoin="round"
					stroke-width="2"
					d="M4 6h16M4 12h16M4 18h16"
				/>
			</svg>

			<div
				class="w-full md:flex md:items-center md:w-auto"
				id="menu"
				v-if="authStore.isLogged"
				:class="{ hidden: navbarOpened }"
			>
				<ul
					class="pt-4 text-base text-gray-700 md:flex md:justify-between md:pt-0"
				>
					<li>
						<router-link
							to="/"
							class="md:p-4 py-2 block hover:text-purple-400"
							:class="activePage('/')"
							v-if="checkAuthorization('/')"
						>
							Home
						</router-link>
					</li>
					<li>
						<router-link
							to="/Calendar"
							class="md:p-4 py-2 block hover:text-purple-400"
							:class="activePage('/Calendar')"
							v-if="checkAuthorization('/Calendar')"
						>
							Calendar
						</router-link>
					</li>
					<li>
						<button
							class="md:p-4 py-2 block hover:text-purple-400"
							@click="logout"
						>
							Sign out
						</button>
					</li>
				</ul>
			</div>
		</nav>
	</header>

	<div
		class="bg-gray-400 min-h-screen p-5"
		:class="pageClass"
	>
		<router-view />
	</div>
</template>
