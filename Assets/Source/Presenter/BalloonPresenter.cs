using Balloons.Model;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
internal class BalloonPresenter : MonoBehaviour
{
    public Transformable Model { get; private set; }

    private readonly BalloonVisitor _balloonVisitor = new BalloonVisitor();

    internal void Init(Transformable model, Color color, BalloonType balloonType)
    {
        Model = model;
        SetSize(balloonType);
        GetComponent<SpriteRenderer>().color = color;
        enabled = true;
    }

    private void OnEnable()
    {
        Model.Moved += UpdatePosition;
        Model.Destroying += Destroy;
        Model.Removing += Destroy;
    }

    private void OnDisable()
    {
        Model.Moved -= UpdatePosition;
        Model.Destroying -= Destroy;
        Model.Removing -= Destroy;
    }

    private void UpdatePosition()
    {
        transform.position = GetVector(Model.Position);
    }

    private void SetSize(BalloonType balloonType)
    {
        _balloonVisitor.Visit(balloonType);
        transform.localScale = _balloonVisitor.Size;
    }

    private void Destroy(Transformable model)
    {
        Model.Moved -= UpdatePosition;
        Model.Destroying -= Destroy;
        Model.Removing -= Destroy;

        LateDestroy();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Play();
    }

    private IEnumerator LateDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private Vector3 GetVector(Position position)
    {
        return new Vector3(position.X, position.Y);
    }

    private class BalloonVisitor : IBalloonVisitor
    {
        public Vector3 Size;

        public void Visit(LittleBalloon balloon)
        {
            Size = new Vector3(Config.LittleSize, Config.LittleSize, 1);
        }

        public void Visit(MediumBalloon balloon)
        {
            Size = new Vector3(Config.MediumSize, Config.MediumSize, 1);
        }

        public void Visit(BigBalloon balloon)
        {
            Size = new Vector3(Config.BigSize, Config.BigSize, 1);
        }

        public void Visit(BalloonType balloon)
        {
            Visit((dynamic)balloon);
        }
    }
}
