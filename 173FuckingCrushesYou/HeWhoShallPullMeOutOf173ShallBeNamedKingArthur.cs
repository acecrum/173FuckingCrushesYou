using CustomPlayerEffects;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Console;
using PlayerRoles;
using PlayerStatsSystem;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace _173FuckingCrushesYou;

public class HeWhoShallPullMeOutOf173ShallBeNamedKingArthur
{
    public void Register()
    {
        PlayerEvents.Hurting += On173FaceSittingMe;
    }
    
    public void Unregister()
    {
        PlayerEvents.Hurting -= On173FaceSittingMe;
    }


    private void On173FaceSittingMe(PlayerHurtingEventArgs ev)
    {
        if (ev.DamageHandler is not UniversalDamageHandler universal || universal.TranslationId != DeathTranslations.Falldown.Id) return;
        if (ev.Player.Role != RoleTypeId.Scp173) return;
        
        foreach (var hub in from hub in ReferenceHub.AllHubs where hub != ev.Player.ReferenceHub where hub.GetTeam() != ev.Player.Team where Vector3.Distance(hub.transform.position, ev.Player.ReferenceHub.transform.position) <= 2f select hub)
        {
            hub.playerStats.DealDamage(new UniversalDamageHandler(150f, DeathTranslations.Crushed, DamageHandlerBase.CassieAnnouncement.Default));
            Hitmarker.SendHitmarkerDirectly(ev.Player.Connection, 1f);
        }
    }
}