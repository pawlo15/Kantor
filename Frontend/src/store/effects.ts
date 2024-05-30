import { AuthEffect } from "./auth/auth.effect";
import { MainEffects } from "./main/main.effect";
import { PanelEffects } from "./panel/panel.effect";
import { RegistrationEffect } from "./registration/registration.effect";

export const rootEffect = [
    MainEffects,
    AuthEffect,
    PanelEffects,
    RegistrationEffect,
    // tu dodajemy effecty
]