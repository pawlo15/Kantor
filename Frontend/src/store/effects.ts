import { AuthEffect } from "./auth/auth.effect";
import { MainEffects } from "./main/main.effect";
import { PanelEffects } from "./panel/panel.effect";

export const rootEffect = [
    MainEffects,
    AuthEffect,
    PanelEffects,
    
    // tu dodajemy effecty
]