﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Object for maintaining the data store for groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperGroupStoreGuid<TUser> : HyperGroupStore<HyperHostGuid, HyperHostDomainGuid, Guid, TUser, HyperRoleGuid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperGroupGuid, HyperGroupRoleGuid, HyperGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperGroupStoreGuid{TUser}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperGroupStoreGuid(HyperDbContextGuid<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");
        }
    }

    /// <summary>
    /// Object for maintaining the data store for groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperGroupStoreInt<TUser> : HyperGroupStore<HyperHostInt, HyperHostDomainInt, int, TUser, HyperRoleInt, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperGroupInt, HyperGroupRoleInt, HyperGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperGroupStoreInt{TUser}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperGroupStoreInt(HyperDbContextInt<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");
        }
    }

    /// <summary>
    /// Object for maintaining the data store for groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperGroupStoreLong<TUser> : HyperGroupStore<HyperHostLong, HyperHostDomainLong, long, TUser, HyperRoleLong, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperGroupLong, HyperGroupRoleLong, HyperGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperGroupStoreLong{TUser}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperGroupStoreLong(HyperDbContextLong<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");
        }
    }

    /// <summary>
    /// Object for maintaining the data store for groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TGroup">The type of the group.</typeparam>
    /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperGroupStore<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : IDisposable
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TKey : struct, IEquatable<TKey>
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TGroup : HyperGroup<TKey, TGroupRole, TGroupUser>, new()
        where TGroupRole : HyperGroupRole<TKey>, new()
        where TGroupUser : HyperGroupUser<TKey>, new()
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>, new()
    {
        protected internal readonly bool GroupsEnabled;
        protected internal readonly HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> HyperContext;

        public bool MultiHostEnabled { get { return HyperContext.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperContext.SystemHostId; } }
        public TKey HostId { get { return HyperContext.HostId; } }

        public bool AutoSaveChanges { get; set; }
        private readonly IDbSet<TGroup> groups;
        private readonly IDbSet<TGroupRole> groupRoles;
        private readonly IDbSet<TGroupUser> groupUsers;
        private readonly IDbSet<TRole> roles;
        private readonly IDbSet<TUser> users;
        private readonly IDbSet<TUserRole> userRoles;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostStore{TGroup, TKey}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperGroupStore(HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            this.HyperContext = context;
            this.AutoSaveChanges = true;
            this.GroupsEnabled = context.RoleGroupsEnabled;

            this.groups = HyperContext.Set<TGroup>();
            this.groupRoles = HyperContext.Set<TGroupRole>();
            this.groupUsers = HyperContext.Set<TGroupUser>();
            this.roles = HyperContext.Set<TRole>();
            this.users = HyperContext.Set<TUser>();
            this.userRoles = HyperContext.Set<TUserRole>();
        }

        // Only call save changes if AutoSaveChanges is true
        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await HyperContext.SaveChangesAsync().WithCurrentCulture();
            }
        }

        /// <summary>
        /// Gets all groups for all hosts.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TGroup> GetAllGroups()
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return groups;
        }

        /// <summary>
        /// Gets all groups for current host plus the system host.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TGroup> GetGroups()
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return GetGroups(this.HostId);
        }

        /// <summary>
        /// Gets all groups for specified host plus the system host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public IQueryable<TGroup> GetGroups(TKey hostId)
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return this.groups.Where(g => g.HostId.Equals(hostId) || g.IsGlobal == true);
        }

        /// <summary>
        /// Creates a <see cref="HyperGroup{TKey, TGroupRoles, TGroupUsers} in the datastore"/>.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global groups must belong to system host.</exception>
        public virtual async Task CreateAsync(TGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            if (group.HostId.Equals(default(TKey)))
            {
                group.HostId = this.HostId;
            }

            if (group.IsGlobal && !group.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global groups must belong to system host.");
            }

            //TODO: check for existing

            groups.Add(group);

            await SaveChanges().WithCurrentCulture();
        }

        /// <summary>
        /// Deletes a <see cref="HyperGroup{TKey, TGroupRoles, TGroupUsers}"/> from the data store.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            //TODO: remove all roles and update all user roles...

            groups.Remove(group);

            await SaveChanges().WithCurrentCulture();
        }

        /// <summary>
        /// Updates an existing <see cref="HyperGroup{TKey, TGroupRoles, TGroupUsers}"/> in the data store.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            //TODO: verify that host id is not changed and that global flags are allowed...

            HyperContext.Entry(group).State = EntityState.Modified;

            //TODO: if roles or users are changed

            await SaveChanges().WithCurrentCulture();
        }

        /// <summary>
        /// Finds a <see cref="HyperGroup{TKey, TGroupRoles, TGroupUsers}"/> by id.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public async Task<TGroup> FindByIdAsync(TKey groupId)
        {
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)));

            ThrowIfDisabled();
            ThrowIfDisposed();

            return await groups.FirstOrDefaultAsync(g => g.HostId.Equals(groupId)).WithCurrentCulture();
        }

        /// <summary>
        /// Finds a <see cref="HyperGroup{TKey, TGroupRoles, TGroupUsers}"/> by name.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public async Task<TGroup> FindByNameAsync(string groupName)
        {
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisabled();
            ThrowIfDisposed();

            return await FindByNameAsync(this.HostId, groupName);
        }

        /// <summary>
        /// Finds a <see cref="HyperGroup{TKey, TGroupRoles, TGroupUsers}" /> by name.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public async Task<TGroup> FindByNameAsync(TKey hostId, string groupName)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)));
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisabled();
            ThrowIfDisposed();

            return await groups.FirstOrDefaultAsync(g => g.Name.ToUpper() == groupName.ToUpper() && (g.HostId.Equals(hostId) || g.IsGlobal == true)).WithCurrentCulture();
        }

        /// <summary>
        /// Gets the roles for the specified group.
        /// </summary>
        /// <param name="hostId">The group identifier.</param>
        /// <returns></returns>
        public async Task<IList<TRole>> GetRolesAsync(TGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var groupId = group.Id;

            var roleIds = groupRoles.Where(gr => gr.GroupId.Equals(groupId)).Select(gr => gr.RoleId).ToArray();

            return await roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
        }

        /// <summary>
        /// Gets the users for the specified group.
        /// </summary>
        /// <param name="hostId">The group identifier.</param>
        /// <returns></returns>
        public async Task<IList<TUser>> GetUsersAsync(TGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var groupId = group.Id;

            var userIds = groupUsers.Where(gu => gu.GroupId.Equals(groupId)).Select(gu => gu.UserId).ToArray();

            return await users.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }

        /// <summary>
        /// Adds a role to the given group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public virtual async Task AddRoleAsync(TGroup group, TRole role)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var groupId = group.Id;
            var roleId = role.Id;

            // check if it already exists
            if (await groupRoles.AnyAsync(gr => gr.GroupId.Equals(groupId) && gr.RoleId.Equals(roleId)))
            {
                throw new ArgumentException(string.Format("Group '{0}' already contains Role {1}.", group.Name, role.Name));
            }
            // global groups can only contain global roles; if they are assignable by host, then the host will be applied when user is assigned to the group
            if (group.IsGlobal && !role.IsGlobal)
            {
                throw new ArgumentException(string.Format("Global group '{0}' can only contain global roles.", group.Name));
            }
            // group can only contain roles from same host or global
            if (!group.IsGlobal && !(role.IsGlobal || role.HostId.Equals(group.HostId)))
            {
                throw new ArgumentException(string.Format("Group '{0}' can only contain roles from the same host or global roles.", group.Name));
            }


            var groupRole = new TGroupRole();
            groupRole.GroupId = groupId;
            groupRole.RoleId = roleId;

            groupRoles.Add(groupRole);

            // update all users in this group to have the new role if they don't already
            RefreshAllUsresInGroup(group.Id);
        }

        public virtual async Task RemoveRoleAsync(TGroup group, TRole role)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var groupId = group.Id;
            var roleId = role.Id;

            var groupRole = await groupRoles.SingleOrDefaultAsync(gr => gr.GroupId.Equals(groupId) && gr.RoleId.Equals(roleId));

            if (groupRole != null)
            {
                groupRoles.Remove(groupRole);
            }

            // update all users in this group to have the new role if they don't already
            RefreshAllUsresInGroup(group.Id);
        }

        private IList<TKey> GetUserIdsForGroup(TKey groupId)
        {
            return groupUsers.Where(gu => gu.GroupId.Equals(groupId)).Select(gu => gu.UserId).ToList();
        }

        private IList<TKey> GetGroupIdsForUser(TKey userId)
        {
            return groupUsers.Where(gu => gu.UserId.Equals(userId)).Select(gu => gu.GroupId).ToList();
        }

        private IList<TKey> GetRoleIdsForGroup(TKey groupId)
        {
            return groupRoles.Where(gr => gr.GroupId.Equals(groupId)).Select(gr => gr.RoleId).ToList();
        }

        private IList<TKey> GetRoleIdsForGroups(IList<TKey> groupIds)
        {
            return groupRoles.Where(gr => groupIds.Contains(gr.GroupId)).Select(gr => gr.RoleId).ToList();
        }

        private IList<TKey> GetRoleIdsForUser(TKey userId)
        {
            var groupIds = GetGroupIdsForUser(userId);

            return groupRoles.Where(gr => groupIds.Contains(gr.GroupId)).Select(gr => gr.RoleId).Distinct().ToList();
        }

        private void RefreshUserRoles(TKey userId)
        {
            var oldRoleIds = GetRoleIdsForUser(userId);
            var groupIds = GetGroupIdsForUser(userId);
            var newRoleIds = GetRoleIdsForGroups(GetGroupIdsForUser(userId));

            var user = users.Find(userId);
            if (user == null)
            {
                // nothing to do...
                return;
            }

            var rolesToRemove = oldRoleIds.Except(newRoleIds);
            foreach (var roleId in rolesToRemove)
            {
                var userRole = userRoles.Where(ur => ur.UserId.Equals(userId) && ur.RoleId.Equals(roleId)).SingleOrDefault();
                if (userRole != null)
                {
                    userRoles.Remove(userRole);
                }
            }

            var rolesToAdd = newRoleIds.Except(oldRoleIds);
            foreach (var roleId in rolesToAdd)
            {
                var role = roles.Find(roleId);
                if (role != null)
                {
                    var userRole = new TUserRole();
                    userRole.HostId = role.HostId;
                    userRole.IsGlobal = role.IsGlobal;
                    userRole.RoleId = roleId;
                    userRole.UserId = userId;

                    userRoles.Add(userRole);
                }
            }
        }

        private void RefreshAllUsresInGroup(TKey groupId)
        {
            // get all the users for this group
            var userIds = GetUserIdsForGroup(groupId);

            // refresh all the roles for each user
            foreach (var userId in userIds)
            {
                RefreshUserRoles(userId);
            }
        }

        private bool AreRolesLoaded(TGroup group)
        {
            return HyperContext.Entry(group).Collection(g => g.Roles).IsLoaded;
        }

        private async Task EnsureRolesLoaded(TGroup group)
        {
            if (!AreRolesLoaded(group))
            {
                var groupId = group.Id;
                await groupRoles.Where(gr => gr.GroupId.Equals(groupId)).LoadAsync().WithCurrentCulture();
                HyperContext.Entry(group).Collection(g => g.Roles).IsLoaded = true;
            }
        }

        private bool AreUsersLoaded(TGroup group)
        {
            return HyperContext.Entry(group).Collection(g => g.Users).IsLoaded;
        }

        private async Task EnsureUsersLoaded(TGroup group)
        {
            if (!AreUsersLoaded(group))
            {
                var groupId = group.Id;
                await groupUsers.Where(gu => gu.GroupId.Equals(groupId)).LoadAsync().WithCurrentCulture();
                HyperContext.Entry(group).Collection(g => g.Users).IsLoaded = true;
            }
        }

        private void ThrowIfDisabled()
        {
            if (!this.GroupsEnabled)
            {
                throw new InvalidOperationException("Groups are not enabled for this context.");
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // TODO: cache references? if so, release them here

                    this.disposed = true;
                }
            }
        }
    }
}
